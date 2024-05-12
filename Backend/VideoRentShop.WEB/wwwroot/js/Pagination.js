function Pagination(url, pagingClass = '.paginationContainer', _itemsPearPage = 5, generateElement) {
    const content = document.querySelector(pagingClass);
    let itemsPerPage = _itemsPearPage; // set number of items per page
    let currentPage = 0;
    let countAll = 0;
    let data = [];

    var _init = function() {
        _showPage(1);
    }

    function _showPage(page) {
        currentPage = page;

        const take = itemsPerPage;
        const skip = (page - 1) * itemsPerPage;

        http.get(url + `?take=${take}&skip=${skip}`, (response) => {
            countAll = response.countAll;
            data = response.data;

            if (data.length == 0 && currentPage != 1) {
                _showPage(currentPage - 1);
            }

            _createPageButtons();
            _updateActiveButtonStates();

            generateElement(data);
        });
    }

    function _createPageButtons() {
        const totalPages = Math.ceil(countAll / itemsPerPage);
        const paginationContainer = document.createElement('div');
        const paginationDiv = document.querySelector(pagingClass);

        paginationDiv.innerHTML = '';
        paginationDiv.appendChild(paginationContainer);
        paginationContainer.classList.add('pagination');

        //Отображаю кнопки пагинации только когда кол-во страниц > 1
        if (totalPages != 1) {
            // Add page buttons
            for (let i = 0; i < totalPages; i++) {
                const pageButton = document.createElement('button');
                pageButton.textContent = i + 1;
                pageButton.addEventListener('click', () => {
                    currentPage = i;
                    _showPage(currentPage + 1);
                    _updateActiveButtonStates();
                });

                paginationDiv.appendChild(pageButton);
            }
        }
    }
    

    function _updateActiveButtonStates() {
        const pageButtons = document.querySelectorAll('.pagination button');
        pageButtons.forEach((button, index) => {
            if (index === currentPage) {
                button.classList.add('active');
            } else {
                button.classList.remove('active');
            }
        });
    }

    return {
        Init: _init,
        ShowPage: _showPage,
        CreatePageButtons: _createPageButtons,
        UpdateActiveButtonStates: _updateActiveButtonStates,
        CurrentPage: currentPage,
    }
}

String.prototype.supplant = function (o) {
    return this.replace(/{([^{}]*)}/g,
        function (a, b) {
            var r = o[b];
            return typeof r === 'string' || typeof r === 'number' ? r : a;
        }
    );
};