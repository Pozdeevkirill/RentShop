function Pagination(pagingClass = '.pagination', url) {
    const content = document.querySelector(pagingClass);
    const itemsPerPage = 2; // set number of items per page
    let currentPage = 0;
    const countAll = 0;

    Init() {
        createPageButtons();
    }

    function showPage(page) {
        const startIndex = page * itemsPerPage;
        const endIndex = startIndex + itemsPerPage;
        items.forEach((item, index) => {
            item.classList.toggle('hidden', index < startIndex || index >= endIndex);
        });
        updateActiveButtonStates();
    }

    function createPageButtons() {
        const totalPages = Math.ceil(countAll / itemsPerPage);
        const paginationContainer = document.createElement('div');
        const paginationDiv = document.body.appendChild(paginationContainer);
        paginationContainer.classList.add('pagination');

        // Add page buttons
        for (let i = 0; i < totalPages; i++) {
            const pageButton = document.createElement('button');
            pageButton.textContent = i + 1;
            pageButton.addEventListener('click', () => {
                currentPage = i;
                showPage(currentPage);
                updateActiveButtonStates();
            });

            content.appendChild(paginationContainer);
            paginationDiv.appendChild(pageButton);
        }
    }

    function updateActiveButtonStates() {
        const pageButtons = document.querySelectorAll('.pagination button');
        pageButtons.forEach((button, index) => {
            if (index === currentPage) {
                button.classList.add('active');
            } else {
                button.classList.remove('active');
            }
        });
    }

    Init();

}