document.getElementById('saveDesignerBtn').addEventListener('click', async function () {
    const errorDiv = document.getElementById('designerModalError');
    const nameInput = document.getElementById('newDesignerName');
    const name = nameInput.value.trim();

    if (!name) {
        errorDiv.textContent = 'Namn krävs.';
        errorDiv.classList.remove('d-none');
        return;
    }

    errorDiv.classList.add('d-none');

    const formData = new FormData();
    formData.append('__RequestVerificationToken', document.querySelector('input[name="__RequestVerificationToken"]').value);
    formData.append('DesignerName', name);
    formData.append('Alias', document.getElementById('newDesignerAlias').value.trim());
    formData.append('Website', document.getElementById('newDesignerWebsite').value.trim());
    formData.append('Handle', document.getElementById('newDesignerHandle').value.trim());

    const response = await fetch('/Designers/CreateModal', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        const designer = await response.json();

        const select = document.querySelector('select[name="Input.DesignerID"]');
        insertOptionSorted(select, designer.id, designer.name);
        select.value = designer.id;

        nameInput.value = '';
        document.getElementById('newDesignerAlias').value = '';
        document.getElementById('newDesignerWebsite').value = '';
        document.getElementById('newDesignerHandle').value = '';

        bootstrap.Modal.getInstance(document.getElementById('createDesignerModal')).hide();
    } else {
        errorDiv.textContent = 'Något gick fel. Försök igen.';
        errorDiv.classList.remove('d-none');
    }
});
