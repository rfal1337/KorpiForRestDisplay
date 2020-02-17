<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
	
	//Check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1"; //Error code #1 = connection failed
		exit();
	}

	$username = $_POST["name"];
	$pin = $_POST["pin"];
	
	$salt = "\$5\$rounds=5000\$" . "nakkivene" . $username . "\$";
	$hash = crypt($pin, $salt);
	$insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
	mysqli_query($con, $insertuserquery) or die("4: Insertion failed");
	
	echo("0");
?>