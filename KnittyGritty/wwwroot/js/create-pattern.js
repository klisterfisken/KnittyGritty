
let sizeCounter = 0;
let yarnCounter = 0;

document.addEventListener('DOMContentLoaded', function () {
    addYarn();
    addSize();
});

function buildSelect(options, name) {
    let html = '<select name="' + name + '" class="form-select form-select-sm">';
    html += '<option value="">-- Välj --</option>';
    options.forEach(function (o) {
        html += '<option value="' + o.value + '">' + o.text + '</option>';
    });
    html += '</select>';
    return html;
}

function addSize() {
    const i = sizeCounter++;
    const row = document.createElement('tr');
    row.innerHTML =
        '<td>' +
        '<input type="hidden" name="Input.Sizes.Index" value="' + i + '" />' +
        buildSelect(sizeOptions, 'Input.Sizes[' + i + '].SizeID') +
        '</td>' +
        '<td><input type="number" name="Input.Sizes[' + i + '].Circumference" class="form-control form-control-sm" /></td>' +
        '<td><input type="text" name="Input.Sizes[' + i + '].Notes" class="form-control form-control-sm" /></td>' +
        '<td><button type="button" class="btn btn-outline-danger btn-sm" onclick="this.closest(\'tr\').remove()">Ta bort</button></td>';
    document.getElementById('sizes-body').appendChild(row);
}

function addYarn() {
    const i = yarnCounter++;
    const row = document.createElement('tr');
    row.innerHTML =
        '<td>' +
        '<input type="hidden" name="Input.SelectedYarns.Index" value="' + i + '" />' +
        buildSelect(yarnOptions, 'Input.SelectedYarns[' + i + '].YarnID') +
        '</td>' +
        '<td><input type="text" name="Input.SelectedYarns[' + i + '].Color" class="form-control form-control-sm" placeholder="Färg (valfritt)" /></td>' +
        '<td><button type="button" class="btn btn-outline-danger btn-sm" onclick="this.closest(\'tr\').remove()">Ta bort</button></td>';
    document.getElementById('yarns-body').appendChild(row);
}

document.getElementById('addYarnBtn').addEventListener('click', addYarn);

document.getElementById('multipleStrands').addEventListener('change', function () {
    document.getElementById('yarnWeightDiv').classList.toggle('d-none', !this.checked);
});

document.getElementById('addSizeBtn').addEventListener('click', addSize);

document.getElementById('yarnBrandSelect').addEventListener('change', function () {
    document.getElementById('newBrandDiv').classList.toggle('d-none', this.value !== 'new');
});

document.getElementById('saveYarnBtn').addEventListener('click', async function () {
    const errorDiv = document.getElementById('yarnModalError');
    const brandSelect = document.getElementById('yarnBrandSelect');
    const newBrandName = document.getElementById('newBrandNameInYarnModal').value.trim();
    const yarnName = document.getElementById('newYarnName').value.trim();

    if (!yarnName) {
        errorDiv.textContent = 'Garnnamn krävs.';
        errorDiv.classList.remove('d-none');
        return;
    }

    if (!brandSelect.value) {
        errorDiv.textContent = 'Välj eller skriv in ett garnmärke.';
        errorDiv.classList.remove('d-none');
        return;
    }

    if (brandSelect.value === 'new' && !newBrandName) {
        errorDiv.textContent = 'Ange ett märkesnamn.';
        errorDiv.classList.remove('d-none');
        return;
    }

    errorDiv.classList.add('d-none');

    const formData = new FormData();
    formData.append('__RequestVerificationToken', document.querySelector('input[name="__RequestVerificationToken"]').value);
    formData.append('YarnName', yarnName);
    formData.append('YarnWeight', document.getElementById('newYarnWeight').value.trim());
    formData.append('UnitWeight', document.getElementById('newYarnUnitWeight').value);
    formData.append('Meterage', document.getElementById('newYarnMeterage').value);
    formData.append('FiberContent', document.getElementById('newYarnFiberContent').value.trim());

    if (brandSelect.value === 'new') {
        formData.append('NewYarnBrandName', newBrandName);
    } else {
        formData.append('YarnBrandID', brandSelect.value);
    }

    const response = await fetch('/Yarns/CreateModal', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        const yarn = await response.json();

        // Lägg till i yarnOptions så det dyker upp i nya rader
        yarnOptions.push({ value: yarn.id, text: yarn.name });

        yarnOptions.sort(function (a, b) {
            return a.text.localeCompare(b.text, 'sv');
        });

        document.querySelectorAll('#yarns-body select').forEach(function (select) {
            const option = document.createElement('option');
            option.value = yarn.id;
            option.textContent = yarn.name;

            const options = Array.from(select.options);
            const insertBefore = options.find(o => o.text.localeCompare(yarn.name, 'sv') > 0);
            if (insertBefore) {
                select.insertBefore(option, insertBefore);
            } else {
                select.appendChild(option);
            }
        });

        // Om nytt märke skapades, lägg till i yarnBrandOptions och selecten
        if (brandSelect.value === 'new') {
            const newOption = document.createElement('option');
            newOption.value = yarn.brandId;
            newOption.textContent = newBrandName;
            brandSelect.insertBefore(newOption, brandSelect.lastElementChild);
        }

        // Rensa och stäng
        document.getElementById('newYarnName').value = '';
        document.getElementById('newYarnWeight').value = '';
        document.getElementById('newYarnUnitWeight').value = '';
        document.getElementById('newYarnMeterage').value = '';
        document.getElementById('newYarnFiberContent').value = '';
        document.getElementById('newBrandNameInYarnModal').value = '';
        brandSelect.value = '';
        document.getElementById('newBrandDiv').classList.add('d-none');

        bootstrap.Modal.getInstance(document.getElementById('createYarnModal')).hide();

    } else {
        errorDiv.textContent = 'Något gick fel. Försök igen.';
        errorDiv.classList.remove('d-none');
    }
});
