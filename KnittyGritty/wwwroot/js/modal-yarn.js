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

        yarnOptions.push({ value: yarn.id, text: yarn.name });
        yarnOptions.sort((a, b) => a.text.localeCompare(b.text, 'sv'));

        document.querySelectorAll('#yarns-body select').forEach(select => {
            insertOptionSorted(select, yarn.id, yarn.name);
        });

        if (brandSelect.value === 'new') {
            const newOption = document.createElement('option');
            newOption.value = yarn.brandId;
            newOption.textContent = newBrandName;
            brandSelect.insertBefore(newOption, brandSelect.lastElementChild);
        }

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
