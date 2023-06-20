$(document).ready(function () {
    const toastTrigger = document.getElementById('liveToastBtn')
    const toastLiveExample = document.getElementById('liveToast')

    if (toastTrigger) {
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
        toastTrigger.addEventListener('click', () => {
            toastBootstrap.show()
        })
    }
    if (window.location.href.endsWith('/User/List')) {
        Manager.GetAllUsers();
    }
    if ($('#submitLogin')) {
        $('#submitLogin').on('click', (event) => {
            Manager.Login();
        });
    }
});

// API for login
var Manager = {

    Login: function () {
        var loginAPI = "https://localhost:7179/api/Member/Login";
        var user = {
            email: $("#Email1").val(),
            password: $("#Password1").val(),
        };
        APIManager.Login(loginAPI, user, onSuccess, onFailed);
        function onSuccess(response) {
            localStorage.setItem('token', response);
            window.location.href = '/User/List';
        }
        function onFailed(xhr, status, error) {
            console.error(error);
            if ($('#liveToastBtn')) {
                $('#liveToastBtn').trigger('click');
            }
            localStorage.clear();
            window.location.href = '/';
        }
    },

    GetAllUsers: () => {
        var url = "https://localhost:7179/api/Member/List";
        if (localStorage.getItem('token') && localStorage.getItem('token')!='') {
            APIManager.GetAPI(url, onSuccess, onFailed);
        } else {
            localStorage.clear();
            window.location.href = '/';
        }
        function onSuccess(response) {
            $('#userTable').DataTable({
                data: response,
                columns: [
                    { data: 'memberId' },
                    { data: 'email' },
                    { data: 'companyName' },
                    { data: 'city' },
                    { data: 'country' }
                ]
            });
        }
        function onFailed(xhr, status, error) {
            console.error(error);
            localStorage.clear();
            window.location.href = '/';
        }
    }

}
// Overall call API

var APIManager = {
    Login: function (serviceUrl, data, successCallback, errorCallback) {
        $.ajax({
            type: "POST",
            url: serviceUrl,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    GetAPI: function (serviceUrl, successCallback, errorCallback) {
        $.ajax({
            type: "GET",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('token')
            },
            dataType: "json",
            success: successCallback,
            error: errorCallback
        });
    },
    PostAPI: function (serviceUrl, data, successCallback, errorCallback) {
        $.ajax({
            type: "POST",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('token')
            },
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    PutAPI: function (serviceUrl, data, successCallback, errorCallback) {
        $.ajax({
            type: "PUT",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('token')
            },
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    DeleteAPI: function (serviceUrl, successCallback, errorCallback) {
        $.ajax({
            type: "DELETE",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + token
            },
            success: successCallback,
            error: errorCallback
        });
    }
};
