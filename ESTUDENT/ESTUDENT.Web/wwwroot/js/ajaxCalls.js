function TableSearch(dataObject, url, data) {

    $.ajax({
        method: "GET",
        url: url,
        data: data,
        success: function (response) {
            var len = $(response).find('.counter-rows').length;
            var pageNumber = 1;
            var rowsPerPage = 9;
            var search = $('#search').val();

            if (len != null && len > 0) {
                dataObject.append(response);
                $(".row-helper").fadeIn();
            }

            if (data.pageNumber == 1) {
                $('#load-old').html("NO MORE DATA");
                $('#load-old').prop('disabled', true);
                
            } else {
                $('#load-old').html("LOAD MORE");
                $('#load-old').prop('disabled', false);
            }

            if (len < data.rowsPerPage) {
                $('#load-more').html("NO MORE DATA");
                $('#load-more').prop('disabled', true);
            } else {
                $('#load-more').html("LOAD MORE");
                $('#load-more').prop('disabled', false);
            }


        },
        error: function () {
            alert("errorText");
        }
    });

}
