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

function insertOptionSorted(select, id, name) {
    const option = document.createElement('option');
    option.value = id;
    option.textContent = name;
    const options = Array.from(select.options);
    const insertBefore = options.find(o => o.text.localeCompare(name, 'sv') > 0);
    if (insertBefore) {
        select.insertBefore(option, insertBefore);
    } else {
        select.appendChild(option);
    }
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
document.getElementById('addSizeBtn').addEventListener('click', addSize);

document.getElementById('multipleStrands').addEventListener('change', function () {
    document.getElementById('yarnWeightDiv').classList.toggle('d-none', !this.checked);
});
