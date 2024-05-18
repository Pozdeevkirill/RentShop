function Input(elementId, requred, type) {
    /*
        type:
            0 -> text
            1 -> number
    */
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
        switch (type) {
            case 0:
                var value = $(elementId).val();
                if ((value == null || value == undefined || value == "") && requred) return false;
                return true;
            case 1: 
                var value = $(elementId).val();
                if ((value < $(elementId).attr("min") || value > $(elementId).attr("max")) && requred) return false;
                return true;
            default:
                console.error("Указан неизвестный тип");
                return false;
        }
    }

    return {
        isValid: isValid,
        validate: validate
    }
}