<#import "default/template.ftlh" as c>

<@c.page>
    <#assign request = springMacroRequestContext.requestUri>
    <div class="row d-flex justify-content-center container m-5">
    <div class="col-md-8">
        <div class="card-hover-shadow-2x mb-3 card">
            <div class="card-header-tab card-header">
                <div class="card-header-title font-size-lg text-capitalize font-weight-normal">
                    <svg class="bi bi-grid" width="1em" height="1em" viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd" d="M9.5 4.5a1 1 0 00-1-1h-4a1 1 0 00-1 1v4a1 1 0 001 1h4a1 1 0 001-1v-4zm-1 7h-4v4h4v-4zm7 0h-4v4h4v-4zm0-7h-4v4h4v-4zm-7 0h-4v4h4v-4zm2 0a1 1 0 011-1h4a1 1 0 011 1v4a1 1 0 01-1 1h-4a1 1 0 01-1-1v-4zm-6 6a1 1 0 00-1 1v4a1 1 0 001 1h4a1 1 0 001-1v-4a1 1 0 00-1-1h-4zm7 0a1 1 0 00-1 1v4a1 1 0 001 1h4a1 1 0 001-1v-4a1 1 0 00-1-1h-4z" clip-rule="evenodd"></path>
                    </svg>
                </div>
            </div>
            <div>
                <form class="m-3" action="${request}" method="post" enctype="multipart/form-data">
                    <input type="hidden" name="_csrf" value="${_csrf.token}">
                    <input type="hidden" name="id" value="${(photo.getId())!""}">

                    <div class="form-group">
                        <label for="file">Выберите файл*:</label>
                        <input id="file" type="file" name="file" class="form-control" accept="image/*">
                    </div>
                    <div class="form-group">
                        <label for="desc">Описание фото:</label>
                        <input type="text" id="desc" name="description" class="form-control"
                               placeholder="Описание фото..." value="${(photo.getDescription())!""}">
                    </div>

                    <button type="submit" class="btn btn-primary">
                        <#if request == "/add">
                            Добавить
                        <#elseif request == "/edit">
                            Изменить
                        </#if>
                    </button>
                </form>
            </div>
        </div>
    </div>
</@c.page>