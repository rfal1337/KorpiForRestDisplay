<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'korpiforrest');

	//Check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1"; //Error code #1 = connection failed
		exit();
	}
	
	$username = $_POST["userID"];
	$pin = $_POST["pin"];
	
	$namecheckquery = "SELECT userID, salt, hash FROM users";
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Check failed");
	
	$existinginfo = mysqli_fetch_assoc($namecheck);
	$salt = $existinginfo["salt"];
	$hash = $existinginfo["hash"];
	
	$loginhash = crypt($pin, $salt);
	
	if($hash != $loginhash)
	{
		echo "6: Incorrect pin";
		exit();
	}
	
	echo "0: Login successful!\t";

?>