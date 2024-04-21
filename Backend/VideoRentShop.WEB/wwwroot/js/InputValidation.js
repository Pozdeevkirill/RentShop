function Input(elementId, requred) {
    const inputSuccsesClass = 'form-control-success';
    const inputDangerClass = 'form-control-danger';

    $(elementId).on("input", validate);

    function validate() {
        if (isValid()) {
            setSuccess();
        }
        else {
            setDanger();
        }
    }

    function setSuccess() {
        $(elementId).removeClass(inputSuccsesClass);
        $(elementId).removeClass(inputDangerClass);
        $(elementId).addClass(inputSuccsesClass);
    }

    function setDanger() {
        $(elementId).removeClass(inputSuccsesClass);
        $(elementId).removeClass(inputDangerClass);
        $(elementId).addClass(inputDangerClass);
    }

    function isValid() {
        var value = $(elementId).val();
        if ((value == null || value == undefined || value == "") && requred) return false; 
        return true;
    }

    return {
        isValid: isValid
    }
}