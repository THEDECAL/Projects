<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<div class="card mb-3" style="max-width: 380px;">
    <div class="row no-gutters">
        <div class="col-md-4">
            <img src="/content/images/${param.imgName}" class="img-thumbnail m-2" alt="..." width="60">
        </div>
        <div class="col-md-8">
            <div class="card-body">
                <h5 class="card-title">${param.brand}&nbsp;${param.model}</h5>
                <p class="card-text"><small class="text-muted">${param.price}&nbsp;грн.</small></p>
                <a href="/cart?delId=${param.id}" class="btn btn-warning">Удалить</a>
            </div>
        </div>
    </div>
</div>