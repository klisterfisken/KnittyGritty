document.getElementById('saveSizeBtn').addEventListener('click', async function () {
    const errorDiv = document.getElementById('sizeModalError');
    const nameInput = document.getElementById('newSizeName');
    const name = nameInput.value.trim();

    if (!name) {
        errorDiv.textContent = 'Namn krävs.';
        errorDiv.classList.remove('d-none');
        return;
    }

    errorDiv.classList.add('d-none');

    const formData = new FormData();
    formData.append('__RequestVerificationToken', document.querySelector('input[name="__RequestVerificationToken"]').value);
    formData.append('SizeName', name);

    const response = await fetch('/Sizes/CreateModal', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        const size = await response.json();

        sizeOptions.push({ value: size.id, text: size.name });
        sizeOptions.sort((a, b) => a.text.localeCompare(b.text, 'sv'));

        document.querySelectorAll('#sizes-body select').forEach(select => {
            insertOptionSorted(select, size.id, size.name);
        });

        nameInput.value = '';
        bootstrap.Modal.getInstance(document.getElementById('createSizeModal')).hide();
    } else {
        errorDiv.textContent = 'Något gick fel. Försök igen.';
        errorDiv.classList.remove('d-none');
    }
});
