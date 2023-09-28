$(document).ready(function () {
    showdata();
    
})

function showdata() {
   $.ajax({
        url: '/AjaxPage?handler=List',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {
            //alert("Data  load");
            var object ='';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.title + '</td>';
                object += '<td>' + item.description + '</td>';

                object += '<td><a a href="#" class="btn btn-info" onclick="Edit(' + item.postId + ')">Edit</a></td>';
                object += '<td><a a href="#" class="btn btn-danger" onclick="Delete(' + item.postId + ')">Delete</a></td>';
                
                object += '<tr>';
            });
            $('#tbl_data').html(object);
        },
        error: function () {
            alert("Data not load");
        }
    });
}


$('#addBlogs').click(function () {
    
    $('#BlogModal').modal('show');
    cleartextboc();
    $('#addbloges').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#Heading').text('Add Blog');

    })


function addbloges() {
    debugger
    var objData = {
        title: $('#title').val(),
        description: $('#descri').val(),
        userName: $('#user').val()
    }
    $.ajax({
        url: '/AjaxPage?handler=Save',
        type: 'Get',
        dataType: 'json',
        data: objData,
        contentType: 'application/xxx-www-form-urlencoded;charset=utf-8;',
        success: function () {
            cleartextboc();
            showdata();
            HidePopUp();
        },
        error: function () {
            alert('data not saved');
        }
    });

   

}

function HidePopUp() {
    $('#BlogModal').modal('hide');
}

    function cleartextboc() {
        $('#title').val('');
        $('#descri').val('');
        $('#user').val('');
    }

   

function Delete(id) {
    if (confirm('Are you sure want to delete the data')) {
        $.ajax({
            url: '/AjaxPage?handler=Delete',
            type: 'Get',
            data: { id: id },
            success: function () {
                alert('delete');
                showdata();
            },
            error: function () {
                alert("not")
            }

        })
    }
        
}

function Edit(id) {
    debugger;
    $.ajax({
        url: '/AjaxPage?handler=Edit',
        type: 'Get',
        data: { id: id },
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (success) {
            $('#BlogId').val(id);
            $('#BlogModal').modal('show');
            $('#title').val(success.title);
            $('#descri').val(success.description);
            $('#user').val(success.userName);
            $('#addbloges').css('display', 'none');
            $('#btnUpdate').css('display', 'block');
            $('#Heading').text('Update Blog');
            //$('#addbloges').hide();
            //$('#btnUpdate').show();
        },
        error: function () {
            alert('not');
        }
    })
}

function UpdateBlog() {

    var objData = {
        postId: $('#BlogId').val(),
        title: $('#title').val(),
        description: $('#descri').val(),
        userName: $('#user').val()
    }
    $.ajax({
        url: '/AjaxPage?handler=Update',
        type: 'Get',
        dataType: 'json',
        data: objData,
        contentType: 'application/xxx-www-form-urlencoded;charset=utf-8;',
        success: function () {
            alert('Data Update');
            showdata();
            cleartextboc();
            
            HidePopUp();
            
        },
        error: function () {
            alert('data not saved');
        }


    })
}   