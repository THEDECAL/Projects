<#macro page>
    <!doctype html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport"
              content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
        <meta http-equiv="X-UA-Compatible">
        <link rel="stylesheet" href="/content/css/style.css">
        <link rel="stylesheet" href="/content/css/bootstrap.min.css">
        <link rel="stylesheet" href="/content/css/font-awesome.min.css">
        <script src="/content/js/jquery.min.js"></script>
        <script src="/content/js/bootstrap.min.js"></script>
        <script src="/content/js/script.js"></script>
        <title>Список Заданий</title>
    </head>
    <body>
        <div class="container">
            <nav class="navbar navbar-light bg-light">
                <a class="navbar-brand btn" href="/">
                    <svg class="bi bi-document-text" width="2em" height="2em" viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd" d="M6 3h8a2 2 0 012 2v10a2 2 0 01-2 2H6a2 2 0 01-2-2V5a2 2 0 012-2zm0 1a1 1 0 00-1 1v10a1 1 0 001 1h8a1 1 0 001-1V5a1 1 0 00-1-1H6z" clip-rule="evenodd"></path>
                        <path fill-rule="evenodd" d="M6.5 14a.5.5 0 01.5-.5h3a.5.5 0 010 1H7a.5.5 0 01-.5-.5zm0-2a.5.5 0 01.5-.5h6a.5.5 0 010 1H7a.5.5 0 01-.5-.5zm0-2a.5.5 0 01.5-.5h6a.5.5 0 010 1H7a.5.5 0 01-.5-.5zm0-2a.5.5 0 01.5-.5h6a.5.5 0 010 1H7a.5.5 0 01-.5-.5zm0-2a.5.5 0 01.5-.5h6a.5.5 0 010 1H7a.5.5 0 01-.5-.5z" clip-rule="evenodd"></path>
                    </svg>
                    &nbsp;Список Заданий
                </a>
                <div class="btn-group btn-group-toggle">
                    <a href="/regin" class="btn btn-primary my-2 my-sm-0">Регистрация</a>
                    <#if login == "anonymousUser">
                        <a href="/login" class="btn btn-outline-primary my-2 my-sm-0">Войти</a>
                    <#else>
                        <a href="/logout" class="btn btn-outline-primary my-2 my-sm-0">(${login}) Выйти</a>
                    </#if>
                </div>
            </nav>
            <#nested>
        </div>
    </body>
    </html>
</#macro>