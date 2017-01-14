<?php

$Hostname = "localhost";
$DBName = "starbreakerstudios";
$User = "root";
$DatabasePassword	= "";

$connect = mysqli_connect($Hostname, $User, $DatabasePassword) or die ("Can't connect to database");
mysqli_select_db($connect, $DBName) or die ("Can't connect to database");

$Email = $_POST["Email"];
$Password = $_POST["Password"];

if(!$Email || !$Password){
	echo"Must fill in all information";
}
else{
	$SQL = "Select password, username FROM accounts WHERE Email = '". $Email ."'";
	$result_id = $connect->query($SQL) or die ("Error in Database");
	$total = mysqli_num_rows($result_id);
	if($total){
		$datas = $result_id->fetch_array(MYSQLI_ASSOC);
		if(strcmp($Password, $datas["password"])){
			echo"Success";
			echo":";
			echo $datas['username'];	
		}else{
			echo"Wrong Password";
		}
	}
	else{
		echo"Email does not exist";
	}
    }
    $connect->close();
?>