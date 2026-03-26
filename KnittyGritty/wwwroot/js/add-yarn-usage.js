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

function addSizeYarn() {
    const i = sizeYarnCounter++;
    const row = document.createElement('tr');
    row.innerHTML =
        '<td>' +
        '<input type="hidden" name="SizeYarns.Index" value="' + i + '" />' +
        buildSelect(sizeOptions, 'SizeYarns[' + i + '].SizeID') +
        '</td>' +
        '<td>' + buildSelect(yarnOptions, 'SizeYarns[' + i + '].YarnID') + '</td>' +
        '<td><input type="number" step="any" name="SizeYarns[' + i + '].SkeinUsage" class="form-control form-control-sm" /></td>' +
        '<td><input type="number" name="SizeYarns[' + i + '].MeterageUsage" class="form-control form-control-sm" /></td>' +
        '<td><button type="button" class="btn btn-outline-danger btn-sm" onclick="this.closest(\'tr\').remove()">Ta bort</button></td>';
    document.getElementById('sizeYarns-body').appendChild(row);
}

document.getElementById('addSizeYarnBtn').addEventListener('click', addSizeYarn);
