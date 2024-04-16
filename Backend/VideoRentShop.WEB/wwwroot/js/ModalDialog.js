function Modal(title, description, type) {
	const idModal = "#modalDialog";

    function _getTemplate(type) {
        switch (type) {
            case 0:
                break;
            case 1:
                return `
                <div class="modal fade show"
					id="success-modal"
					tabindex="-1"
					role="dialog"
					aria-labelledby="exampleModalCenterTitle"
					aria-hidden="true"
					id="${idModal}">
					<div
						class="modal-dialog modal-dialog-centered"
						role="document">
						<div class="modal-content">
							<div class="modal-body text-center font-18">
								<h3 class="mb-20">${title}</h3>
								<div class="mb-30 text-center">
									<img src="vendors/images/success.png" />
								</div>
								${description}
							</div>
							<div class="modal-footer justify-content-center">
								<button
									type="button"
									class="btn btn-primary"
									data-dismiss="modal">
									Закрыть
								</button>
							</div>
						</div>
					</div>
				</div>
				<div class="modal-backdrop fade show"></div>
                `
                break;
        }
    }

	function showModal() {
		closeModal();
		$(".main-container").append(_getTemplate(type));
    }

	function closeModal() {
		$(idModal).remove();
    }

    return {
        show: showModal,
        close: closeModal
    }
}