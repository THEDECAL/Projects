<#import "default/template.ftlh" as c>
<#include "default/account.ftlh">
<@c.page>
    <div class="jumbotron">
        <div id="carouselExampleFade" class="carousel slide carousel-fade slider" data-ride="carousel">
            <ol class="carousel-indicators">
                <#list photos as photo>
                    <#if photo?index < 3>
                        <li data-target="#carouselExampleIndicators" data-slide-to="${photo?index}"></li>
                    </#if>
                </#list>
                <li data-target="#carouselExampleIndicators" data-slide-to="3" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
            </ol>
            <div class="carousel-inner">
                <#list photos as photo>
                    <#if photo?index < 3>
                        <div class="carousel-item">
                            <img src="/img/${photo.getImgName()}" class="d-block w-100 slider-img" alt="...">
                            <#if photo.getDescription()??>
                                <div class="slider-desc carousel-caption d-none d-md-block">
                                    <h3>${photo.getDescription()}</h3>
                                </div>
                            </#if>
                        </div>
                        <#else><#break>
                    </#if>
                </#list>
                <div class="carousel-item active">
                    <img src="/img/a431273e-55d5-431c-9124-c189eebf7736.jpg" class="d-block w-100 slider-img" alt="...">
                    <div class="slider-desc carousel-caption d-none d-md-block">
                        <h3>Мороженка...</h3>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="/img/f1802bbd-9373-48ac-8627-665dd85d63fa.jpg" class="d-block w-100 slider-img" alt="...">
                    <div class="slider-desc carousel-caption d-none d-md-block">
                        <h3>Девушка...</h3>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleFade" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleFade" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
    <div class="card-columns">
        <#list photos as photo>
            <div class="card">
                <#if photo.getDescription()??>
                    <div class="card-header">
                        <p class="text-center m-0">${photo.getDescription()}</p>
                    </div>
                </#if>
                <div class="position-absolute w-100 d-flex justify-content-between">
                    <#if account??>
                        <#if account.getLogin() == photo.getOwner().getLogin()>
                            <a href="/edit?id=${photo.getId()}">
                                <svg class="bi bi-pencil btn-outline-primary m-2" width="1.5em" height="1.5em"
                                     viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                    <path fill-rule="evenodd"
                                          d="M13.293 3.293a1 1 0 011.414 0l2 2a1 1 0 010 1.414l-9 9a1 1 0 01-.39.242l-3 1a1 1 0 01-1.266-1.265l1-3a1 1 0 01.242-.391l9-9zM14 4l2 2-9 9-3 1 1-3 9-9z"
                                          clip-rule="evenodd"></path>
                                    <path fill-rule="evenodd"
                                          d="M14.146 8.354l-2.5-2.5.708-.708 2.5 2.5-.708.708zM5 12v.5a.5.5 0 00.5.5H6v.5a.5.5 0 00.5.5H7v.5a.5.5 0 00.5.5H8v-1.5a.5.5 0 00-.5-.5H7v-.5a.5.5 0 00-.5-.5H5z"
                                          clip-rule="evenodd"></path>
                                </svg>
                            </a>
                            <a href="/remove?id=${photo.getId()}">
                                <svg class="bi bi-trash btn-outline-danger m-2" width="1.5em" height="1.5em"
                                     viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M7.5 7.5A.5.5 0 018 8v6a.5.5 0 01-1 0V8a.5.5 0 01.5-.5zm2.5 0a.5.5 0 01.5.5v6a.5.5 0 01-1 0V8a.5.5 0 01.5-.5zm3 .5a.5.5 0 00-1 0v6a.5.5 0 001 0V8z"></path>
                                    <path fill-rule="evenodd"
                                          d="M16.5 5a1 1 0 01-1 1H15v9a2 2 0 01-2 2H7a2 2 0 01-2-2V6h-.5a1 1 0 01-1-1V4a1 1 0 011-1H8a1 1 0 011-1h2a1 1 0 011 1h3.5a1 1 0 011 1v1zM6.118 6L6 6.059V15a1 1 0 001 1h6a1 1 0 001-1V6.059L13.882 6H6.118zM4.5 5V4h11v1h-11z"
                                          clip-rule="evenodd"></path>
                                </svg>
                            </a>
                        </#if>
                    </#if>
                </div>
                <img src="/img/${photo.getImgName()}" class="card-img-top" alt="...">
                <div class="card-footer d-flex justify-content-between">
                    <small class="text-muted">${photo.getAddedDate()}</small>
                    <small class="text-muted">${photo.getOwner().getLogin()}</small>
                </div>
            </div>
        <#else>
            <h3 class="text-center">Нет ни одной картинки.</h3>
        </#list>
    </div>
</@c.page>
