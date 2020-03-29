var el = null;
function activDiactiv(event){
    el = event;
    var id = Number(event.parentElement.firstElementChild.value);

    location.href = "http://" + document.location.host + "/active-remove?activeId=" + id;
}