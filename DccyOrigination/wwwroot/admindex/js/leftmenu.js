$(function () {

    function createLeftMenu() {
        $.get({
            url: '~/Menu/GetLeftMenuTreeData',
            function(data) {
                if (data.StateCode==200) {
                    asideTpl(data.Data);
                }
                if (data.StateCode==301) {
                    $.get("../Login/Index");
                }
            }  
        })
    }

    function asideTpl(res) {
        var tpl = '<ul id="accordion" class="nav nav-sidbar">';
        res.forEach(function (val) {
            tpl += '<li class="panel"><a data-parent="#accordion" href="javascript:;" data-toggle="collapse" data-url="' + val.url + '" data-target="#parent-' + val.id + '" id="parent-a-' + val.id + '" class="parent jumpiframe">'
                + val.name + '</a><ul class="nav collapse" id="parent-' + val.id + '">' + createli(val.id, val.list, "") + '</ul></li>';
        });
        return tpl + '</ul';
    }
    function createli(pid, data, str) {
        data && data.forEach(function (val) {
            str += '<li class="panel"><a style="text-indent: 10px" href="javascript:;" data-toggle="collapse" data-parent="#parent-' + pid + '" data-url="' + val.url + '" data-target="#parent-' + val.id + '" id="parent-a-' + val.id + '" class="children jumpiframe">'
                + val.name + '</a><ul class="nav collapse" id="parent-' + val.id + '">' + createli(val.id, val.list, "") + '</ul></li>';
        });
        return str;
    }
    html = asideTpl();
    document.querySelector('#left_menu').innerHTML = html;
    $(".jumpiframe").on('click', function () {
        var indent = $(this).css('text-indent'),
            jumpClass = $(this).attr('class');
        if (/children/.test(jumpClass)) {
            $(this).next().children('li').children('a').css('text-indent', indent.match(/\d+/g)[0] - 0 + 10 + 'px');
        }
    })
});