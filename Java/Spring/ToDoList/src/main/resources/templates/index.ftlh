<#import "default/template.ftlh" as c>

<@c.page>
    <div class="row d-flex justify-content-center container m-5">
        <div class="col-md-8">
            <div class="card-hover-shadow-2x mb-3 card">
                <div class="card-header-tab card-header">
                    <div class="card-header-title font-size-lg font-weight-normal">
                        <svg class="bi bi-grid" width="1em" height="1em" viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M9.5 4.5a1 1 0 00-1-1h-4a1 1 0 00-1 1v4a1 1 0 001 1h4a1 1 0 001-1v-4zm-1 7h-4v4h4v-4zm7 0h-4v4h4v-4zm0-7h-4v4h4v-4zm-7 0h-4v4h4v-4zm2 0a1 1 0 011-1h4a1 1 0 011 1v4a1 1 0 01-1 1h-4a1 1 0 01-1-1v-4zm-6 6a1 1 0 00-1 1v4a1 1 0 001 1h4a1 1 0 001-1v-4a1 1 0 00-1-1h-4zm7 0a1 1 0 00-1 1v4a1 1 0 001 1h4a1 1 0 001-1v-4a1 1 0 00-1-1h-4z" clip-rule="evenodd"></path>
                        </svg>
                    </div>
                </div>
                <div class="scroll-area-sm">
                    <perfect-scrollbar class="ps-show-limits">
                        <div style="position: static;" class="ps ps--active-y">
                            <div class="ps-content">
                                <ul class=" list-group list-group-flush">
                                    <#list tasks as t>
                                        <li class="list-group-item">
                                            <div class="widget-content p-0">
                                                <div class="widget-content-wrapper">
                                                    <div class="widget-content-left mr-2">
                                                        <div class="custom-checkbox custom-control">
                                                            <input type="hidden" value="${t.getId()}">
                                                            <input class="custom-control-input"
                                                                   id="exampleCustomCheckbox12"
                                                                   type="checkbox" ${t.getIsActive()?then('','checked')}
                                                                   onclick="activDiactiv(event.currentTarget)">
                                                            <label class="custom-control-label" for="exampleCustomCheckbox12">&nbsp;</label>
                                                        </div>
                                                    </div>
                                                    <div class="widget-content-left flex2">
                                                        <div class="widget-heading ${t.getIsActive()?then('','diactivated')}">
                                                            <#if t.getText()??>
                                                                ${t.getText()}
                                                            <#else>
                                                            </#if>
                                                        </div>
                                                        <div class="widget-subheading">
                                                            <#if t.getOwner()??>
                                                                ${t.getOwner().getLogin()}
                                                            <#else>
                                                            </#if>
                                                        </div>
                                                    </div>
                                                    <div class="widget-content-right">
                                                        <a href="/add-edit?id=${t.getId()}" class="border-0 btn-transition btn btn-outline-success">
                                                            <svg class="bi bi-pencil" width="1.2em" height="1.2em" viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                                                <path fill-rule="evenodd" d="M13.293 3.293a1 1 0 011.414 0l2 2a1 1 0 010 1.414l-9 9a1 1 0 01-.39.242l-3 1a1 1 0 01-1.266-1.265l1-3a1 1 0 01.242-.391l9-9zM14 4l2 2-9 9-3 1 1-3 9-9z" clip-rule="evenodd"></path>
                                                                <path fill-rule="evenodd" d="M14.146 8.354l-2.5-2.5.708-.708 2.5 2.5-.708.708zM5 12v.5a.5.5 0 00.5.5H6v.5a.5.5 0 00.5.5H7v.5a.5.5 0 00.5.5H8v-1.5a.5.5 0 00-.5-.5H7v-.5a.5.5 0 00-.5-.5H5z" clip-rule="evenodd"></path>
                                                            </svg>
                                                        </a>
                                                        <a href="/active-remove?removeId=${t.getId()}" class="border-0 btn-transition btn btn-outline-danger">
                                                            <svg class="bi bi-trash" width="1.2em" height="1.2em" viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                                                <path d="M7.5 7.5A.5.5 0 018 8v6a.5.5 0 01-1 0V8a.5.5 0 01.5-.5zm2.5 0a.5.5 0 01.5.5v6a.5.5 0 01-1 0V8a.5.5 0 01.5-.5zm3 .5a.5.5 0 00-1 0v6a.5.5 0 001 0V8z"></path>
                                                                <path fill-rule="evenodd" d="M16.5 5a1 1 0 01-1 1H15v9a2 2 0 01-2 2H7a2 2 0 01-2-2V6h-.5a1 1 0 01-1-1V4a1 1 0 011-1H8a1 1 0 011-1h2a1 1 0 011 1h3.5a1 1 0 011 1v1zM6.118 6L6 6.059V15a1 1 0 001 1h6a1 1 0 001-1V6.059L13.882 6H6.118zM4.5 5V4h11v1h-11z" clip-rule="evenodd"></path>
                                                            </svg>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <#else>
                                            <h4 class="text-center my-2">Нет ни одного задания.</h4>
                                    </#list>
<#--                                    <li class="list-group-item">-->
<#--                                        <div class="todo-indicator bg-warning"></div>-->
<#--                                        <div class="widget-content p-0">-->
<#--                                            <div class="widget-content-wrapper">-->
<#--                                                <div class="widget-content-left mr-2">-->
<#--                                                    <div class="custom-checkbox custom-control"> <input class="custom-control-input" id="exampleCustomCheckbox12" type="checkbox"><label class="custom-control-label" for="exampleCustomCheckbox12">&nbsp;</label> </div>-->
<#--                                                </div>-->
<#--                                                <div class="widget-content-left">-->
<#--                                                    <div class="widget-heading">Call Sam For payments <div class="badge badge-danger ml-2">Rejected</div>-->
<#--                                                    </div>-->
<#--                                                    <div class="widget-subheading"><i>By Bob</i></div>-->
<#--                                                </div>-->
<#--                                                <div class="widget-content-right"> <button class="border-0 btn-transition btn btn-outline-success"> <i class="fa fa-check"></i></button> <button class="border-0 btn-transition btn btn-outline-danger"> <i class="fa fa-trash"></i> </button> </div>-->
<#--                                            </div>-->
<#--                                        </div>-->
<#--                                    </li>-->
                                </ul>
                            </div>
                        </div>
                    </perfect-scrollbar>
                </div>
                <div class="d-block text-right card-footer"><a href="/add-edit" class="btn btn-primary">Добавить задание</a></div>
            </div>
        </div>
    </div>
</@c.page>
