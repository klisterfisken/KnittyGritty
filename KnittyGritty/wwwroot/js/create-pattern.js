
let sizeCounter = 0;
let sizeYarnCounter = 0;

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

function addSizeYarn() {
    const i = sizeYarnCounter++;
    const row = document.createElement('tr');
    row.innerHTML =
        '<td>' +
        '<input type="hidden" name="Input.SizeYarns.Index" value="' + i + '" />' +
        buildSelect(sizeOptions, 'Input.SizeYarns[' + i + '].SizeID') +
        '</td>' +
        '<td>' + buildSelect(yarnOptions, 'Input.SizeYarns[' + i + '].YarnID') + '</td>' +
        '<td><input type="number" step="any" name="Input.SizeYarns[' + i + '].SkeinUsage" class="form-control form-control-sm" /></td>' +
        '<td><input type="number" name="Input.SizeYarns[' + i + '].MeterageUsage" class="form-control form-control-sm" /></td>' +
        '<td><button type="button" class="btn btn-outline-danger btn-sm" onclick="this.closest(\'tr\').remove()">Ta bort</button></td>';
    document.getElementById('sizeYarns-body').appendChild(row);
}

document.getElementById('multipleStrands').addEventListener('change', function () {
    document.getElementById('yarnWeightDiv').classList.toggle('d-none', !this.checked);
});

document.getElementById('addSizeBtn').addEventListener('click', addSize);
document.getElementById('addSizeYarnBtn').addEventListener('click', addSizeYarn);