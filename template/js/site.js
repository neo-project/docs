//为中文和英文之间添加空格
text_replace(".with-space");
//代码高亮
hljs.initHighlightingOnLoad();
//目录展开和收起
$(function () {
    $(".catalog nav span").click(function () {
        if ($(this).hasClass('expand'))
            $(this).removeClass('expand');
        else
            $(this).addClass('expand');
        $(this).next("nav").toggle("fast");
    });
});
//根据网址自动展开到对应目录
$(function () {
    var pathName = decodeURI(location.pathname);
    var link = $(".catalog").find("[href='" + pathName + "']")[0];
    $(link).addClass("active");
    $(link).parents().show();
    $(link).parents().prev().addClass('expand');
});
//懒加载
$(function () {
    $('[data-original]').lazyload({
        threshold: 200,
        effect: "fadeIn"
    });
});
//代码复制
$(function () {
    var clipboard = new ClipboardJS('.btn-clipboard');
    clipboard.on('success', function (t) {
        $(t.trigger).attr("title", "Copied!").tooltip("_fixTitle").tooltip("show").attr("title", "Copy to clipboard").tooltip("_fixTitle");
    });
    clipboard.on("error", function (t) {
        var e = /Mac/i.test(navigator.userAgent) ? "⌘" : "Ctrl-";
        var n = "Press " + e + "C to copy";

        $(t.trigger).attr("title", n).tooltip("_fixTitle").tooltip("show").attr("title", "Copy to clipboard").tooltip("_fixTitle")
    });
});
//语言切换
function language(lang) {
    var rgExp = /\/\w{2}-\w{2}\//;
    localStorage.setItem("lang", lang);
    if (location.href.search(rgExp) >= 0) {
        location.href = location.href.replace(rgExp, `/${lang}/`);
    }
}
//工具提示
$('[data-toggle="tooltip"]').tooltip();
//小屏时显示隐藏目录
function showCatalog() {
    if ($('.catalog').hasClass('show'))
        $('.catalog').removeClass('show');
    else
        $('.catalog').addClass('show');
}
//为块引用添加图标
$(function () {
    $(".bd-callout-info h4").prepend("<i class='fas fa-info-circle'></i>");
    $(".bd-callout-warning h4").prepend("<i class='fas fa-exclamation-circle'></i>");
    $(".bd-callout-danger h4").prepend("<i class='fas fa-exclamation-triangle'></i>");
});
//Google Analyse
window.dataLayer = window.dataLayer || [];
function gtag() { dataLayer.push(arguments); }
gtag('js', new Date());
gtag('config', 'UA-130525731-2');