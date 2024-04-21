function HttpClient() {

	var errorCallback = function (response) {
		Swal.fire({
			title: response.title,
			text: response.message,
			icon: "error"
		});
	}

    var _get = function (url, successCallback) {
		$.ajax({
			type: "GET",
			url: url,
			success: successCallback,
			error: (response) => errorCallback(response.responseJSON)
		});
	}

	var _post = function (url, data, successCallback) {
		_clearPost(url, JSON.stringify(data), "application/json", successCallback);
	}

	var _postForm = function (url, data, successCallback) {
		let _data = {};
		if (data instanceof FormData) {
			_data = data;
		} else {
			_data = data.serialize();
		}

		$.ajax({
			type: "POST",
			url: url,
			data: _data,
			processData: false,
			success: (response) => successCallback(response),
			error: (response) => errorCallback(response.responseJSON)
		});

		//_clearPost(url, data.serialize(), "application/x-www-form-urlencoded; charset=UTF-8", successCallback);
	}

	var _clearPost = function (url, data, reqContentType, successCallback) {
		$.ajax({
			type: "POST",
			url: url,
			data: data,
			contentType: reqContentType,
			processData: false,
			success: (response) => successCallback(response),
			error: (response) => errorCallback(response.responseJSON)
		});
	}

    return {
        get: _get,
		post: _post,
		postForm: _postForm,
		clearPost: _clearPost,
    }
}