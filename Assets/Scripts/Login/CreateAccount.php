
<?Php
$Email = $_REQUEST["Email"];
$Password = $_REQUEST["Password"];
$Username = $_REQUEST["Username"];
//PHP only
$Hostname = "localhost";
$DBName = "accounts";
$User = "root";
$DataBasePassword = "";
mysql_connect($Hostname, $User, $DataBasePassword) or die ("Can't connect to database");
mysql_select_db($DBName) or die ("Can't connect to database");
if(!$Email || !$Password || !$Username){
	echo"Empty";
}
else{
	$SQL = "Select * FROM accounts WHERE Email = '". $Email ."'";
	$Result = @mysql_query($SQL) or die ("Error in Database");
	$Total = mysql_num_rows($Result);
	if($Total == 0){
		$insert = "INSERT INTO `accounts` (`Email`,`Password`, `Username`) VALUES ('" . $Email . "', MD5('" . $Password . "'),'" . $Username . "')";
		$SQL1 = mysql_query($insert);
		echo "Success";   
		
	}else{
		echo"AlreadyUsed";
	}
}
mysql_close();
?>