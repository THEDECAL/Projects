<#import "default/template.ftlh" as c>

<@c.page>
    <div class="row d-flex justify-content-center container m-5">
        <div class="col-md-8">
            <section class="page_404">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 ">
                            <div class="col-sm-10 col-sm-offset-1  text-center">
                                <div class="four_zero_four_bg">
                                    <h2 class="text-center ">Ошибка</h2>
                                    <h4>${(error_text)!""}</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
<#--            <div>-->
<#--                <h3>Ошибка</h3>-->
<#--                <#if error_text??>-->
<#--                    <p>${error_text}</p>-->
<#--                </#if>-->
<#--            </div>-->
        </div>
    </div>
</@c.page>