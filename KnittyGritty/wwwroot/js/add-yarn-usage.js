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

function addSizeYarn(prefill) {
    const i = sizeYarnCounter++;
    const row = document.createElement('tr');
    row.innerHTML =
        '<td>' +
        '<input type="hidden" name="SizeYarns.Index" value="' + i + '" />' +
        buildSelect(sizeOptions, 'SizeYarns[' + i + '].SizeID') +
        '</td>' +
        '<td>' + buildSelect(yarnOptions, 'SizeYarns[' + i + '].PatternYarnID') + '</td>' +
        '<td><input type="number" name="SizeYarns[' + i + '].GramUsage" class="form-control form-control-sm" /></td>' +
        '<td><input type="number" name="SizeYarns[' + i + '].MeterageUsage" class="form-control form-control-sm" /></td>' +
        '<td><button type="button" class="btn btn-outline-danger btn-sm" onclick="this.closest(\'tr\').remove()">Ta bort</button></td>';
    document.getElementById('sizeYarns-body').appendChild(row);

    if (prefill) {
        row.querySelector('[name$=".SizeID"]').value = prefill.sizeID;
        row.querySelector('[name$=".PatternYarnID"]').value = prefill.patternYarnID;
        row.querySelector('[name$=".GramUsage"]').value = prefill.gramUsage;
        row.querySelector('[name$=".MeterageUsage"]').value = prefill.meterageUsage;
    }
}

document.getElementById('addSizeYarnBtn').addEventListener('click', function () {
    addSizeYarn(null);
});

document.addEventListener('DOMContentLoaded', function () {
    existingEntries.forEach(function (entry) {
        addSizeYarn(entry);
    });
});
