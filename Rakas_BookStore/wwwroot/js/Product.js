$(() => {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#prodTable').DataTable({
        ajax: { url:'/Admin/Product/GetAll'},
        columns: [
            { data: 'title', width: "25%" },
            { data: 'isbn', width: "15%" },
            { data: 'listPrice', width: "10%" },
            { data: 'author', width: "15%" },
            { data: 'category.name', width: "10%" },
            {
                data: 'id',
                render: (data) => {
                    return `
                    <div class="w-auto btn-group" role="group">
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                        <a href="/admin/product/delete/${data}" class="btn btn-primary mx-2"><i class="bi bi-trash"></i>Delete</a>
                    </div>`
                },
                width: "25%"
            }
        ]
    });
}

