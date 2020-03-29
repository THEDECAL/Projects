<#if Session["SPRING_SECURITY_CONTEXT"]??>
    <#assign account = Session["SPRING_SECURITY_CONTEXT"].authentication.principal>
</#if>