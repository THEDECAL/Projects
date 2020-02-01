<#include "account.ftlh">
<#macro page>
    <!doctype html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport"
              content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
        <meta http-equiv="X-UA-Compatible">
        <link rel="stylesheet" href="/content/css/bootstrap.min.css">
        <link rel="stylesheet" href="/content/css/style.css">
        <script src="/content/js/jquery.min.js"></script>
        <script src="/content/js/bootstrap.min.js"></script>
        <title>Список Заданий</title>
    </head>
    <body>
    <div class="container">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand btn" href="/">
                <svg class="bi bi-image btn-outline-primary" width="1.5em" height="1.5em" viewBox="0 0 20 20" fill="currentColor"
                     xmlns="http://www.w3.org/2000/svg">
                    <path fill-rule="evenodd"
                          d="M16.002 4h-12a1 1 0 00-1 1v10a1 1 0 001 1h12a1 1 0 001-1V5a1 1 0 00-1-1zm-12-1a2 2 0 00-2 2v10a2 2 0 002 2h12a2 2 0 002-2V5a2 2 0 00-2-2h-12z"
                          clip-rule="evenodd"></path>
                    <path d="M12.648 9.646a.5.5 0 01.577-.093l3.777 1.947V16h-14v-2l2.646-2.354a.5.5 0 01.63-.062l2.66 1.773 3.71-3.71z"></path>
                    <path fill-rule="evenodd" d="M6.502 9a1.5 1.5 0 100-3 1.5 1.5 0 000 3z" clip-rule="evenodd"></path>
                </svg>
                &nbsp;Галерея&nbsp;
            </a>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="/add">
                            <svg class="bi bi-plus" width="1em" height="1em" viewBox="0 0 20 20" fill="currentColor"
                                 xmlns="http://www.w3.org/2000/svg">
                                <path fill-rule="evenodd"
                                      d="M10 5.5a.5.5 0 01.5.5v4a.5.5 0 01-.5.5H6a.5.5 0 010-1h3.5V6a.5.5 0 01.5-.5z"
                                      clip-rule="evenodd"></path>
                                <path fill-rule="evenodd"
                                      d="M9.5 10a.5.5 0 01.5-.5h4a.5.5 0 010 1h-3.5V14a.5.5 0 01-1 0v-4z"
                                      clip-rule="evenodd"></path>
                            </svg>
                            Добавить фото
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/index?myPhoto=true">
                            <svg class="bi bi-box-arrow-up-right" width="1em" height="1em" viewBox="0 0 20 20"
                                 fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                <path fill-rule="evenodd"
                                      d="M3.5 15A1.5 1.5 0 005 16.5h8a1.5 1.5 0 001.5-1.5v-4a.5.5 0 00-1 0v4a.5.5 0 01-.5.5H5a.5.5 0 01-.5-.5V7a.5.5 0 01.5-.5h4a.5.5 0 000-1H5A1.5 1.5 0 003.5 7v8zm7-11a.5.5 0 01.5-.5h5a.5.5 0 01.5.5v5a.5.5 0 01-1 0V4.5H11a.5.5 0 01-.5-.5z"
                                      clip-rule="evenodd"></path>
                                <path fill-rule="evenodd"
                                      d="M16.354 3.646a.5.5 0 010 .708l-8 8a.5.5 0 01-.708-.708l8-8a.5.5 0 01.708 0z"
                                      clip-rule="evenodd"></path>
                            </svg>
                            Мои фото
<#--                            <span class="badge badge-primary badge-pill">${(photos)!""}</span>-->
                        </a>
                    </li>
                </ul>
            </div>
            <form class="form-inline my-2 my-lg-0 btn-group btn-group-toggle" action="/logout" method="post">
                <a href="/regin" class="btn btn-primary my-2 my-sm-0">Регистрация</a>
<#--                <#if Session["SPRING_SECURITY_CONTEXT"]??>-->
<#--                    <#assign account = Session["SPRING_SECURITY_CONTEXT"].authentication.principal>-->
                <#if account??>
                    <input type="hidden" name="_csrf" value="${_csrf.token}">
                    <button type="submit" class="btn btn-outline-primary my-2 my-sm-0">(${account.getLogin()}) Выйти</button>
                <#else>
                    <a href="/login" class="btn btn-outline-primary my-2 my-sm-0">Войти</a>
                </#if>
            </form>
        </nav>
        <div class="container m-1">
            <#nested>
        </div>
    </div>
    </body>
    </html>
</#macro>