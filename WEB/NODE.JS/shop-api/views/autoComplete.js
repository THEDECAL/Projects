// $("#mx1045").value - Подробное описание
// $("#mx1037").value - Тема

// tabClick('mx282') - Журнал

// document.getElementById('mx4553').click() - новая строка

// $("#mx4424") - Тема в новой строке
// $("#mx4432  ") - Описание в новой строке

// setClickPosition(this, event);sendEvent("click","mx4183","") - Выпонить

// $("#mx4243").checked = true - RadioButton Выполнить
// document.getElementById('mx4236').click() - Выполнить


const Theme = $("#mx1037").value
const Desc = $("#mx1045").value
setTimeout(() => {
    tabClick('mx282')
    setTimeout(() => {
        const theme = document.getElementById('mx4424')
        const desc = document.getElementById('mx4432')

        theme.focus(); theme.blur()
        theme.click()
        theme.focus(); theme.blur()


        setTimeout(
            $(".text.multilinetextbox.ibta.tareq[ctype=textarea][escamp=false]").value = Desc
        $(".text:not(.tt).ib.tbreq[ctype=textbox][title=Тема ]").value = Theme
    })
}, 2000)
