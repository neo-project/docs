function openTab(event, pageName) {
    var i, tabcontent, tablinks;
    tabcontents = document.getElementsByClassName("tab-content");
    for ( i = 0; i < tabcontents.length; i++) {
        tabcontents[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(pageName).style.display = "block";
    event.currentTarget.className += " active";
}

document.getElementById("defaultOpen").click();