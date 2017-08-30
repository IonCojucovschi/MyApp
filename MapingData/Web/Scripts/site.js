function aply() {

    //var ele = $("#username");///$  jquery    # in string 
    //ele.text("Shawn Wildermutl");


    //var main =$("#main");
    //main.on("mouseenter", function () {
    //    main.style = "background:#888";
    //});

    //main.on("mouseleave", function () {
    //    main.style = "";
    //});

    //var menuItems = $("ul.menu li a");

    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});



    //////////////////

    var $userinfo = $("#userInfo");

    $("#USbut").on("click", function () {
        $userinfo.toggleClass("hide-userinfo")

        if ($userinfo.hasClass("hide-userinfo")) {
            $(this).text("Show userinfo");
        } else {
            $(this).text("Hide userinfo");
        }
    });
 }
aply();












