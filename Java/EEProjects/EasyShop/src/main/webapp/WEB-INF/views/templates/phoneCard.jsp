<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<div class="card border-primary mb-3" style="max-width: 18rem;">
    <div class="card-header bg-transparent border-primary">
        ${param.brand}&nbsp;${param.model}
        <p class="card-text text-right"><small class="text-muted">${param.price}&nbsp;грн.</small></p>
    </div>
    <div class="card-body text-success">
        <img src="/content/images/${param.imgName}" class="img-thumbnail"/>
    </div>
    <div class="card-footer bg-transparent border-primary text-center">
        <a href="/cart?id=${param.id}" class="btn btn-primary btn-sm">В корзину</a>
    </div>
</div>