function getXmlHttp(){
	var xmlHttp;
	try{
		xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
	}
	catch(e){
		try{
			xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		}
		catch(E){
			xmlHttp = false;
		}
	}
	if(!xmlHttp && typeof XMLHttpRequest != "undefined"){
		xmlHttp = new XMLHttpRequest();
	}
	return xmlHttp;
}

function checkLogin(login){
	var xmlHttp = getXmlHttp();
	xmlHttp.open("POST", "/../../app/controllers/check_login.php");
	xmlHttp.setRequestHeader("Content-type","application/x-www-form-urlencoded");
	xmlHttp.send("login=" + encodeURIComponent(login));
	xmlHttp.onreadystatechange = function(){
		if(xmlHttp.readyState == 4){
			if(xmlHttp.status == 200){
				if(xmlHttp.responseText == "п»їп»їok") alert("Логин свободен");
				else alert("Логин занят");
				//alert(xmlHttp.responseText);
			}
		}
	}
}