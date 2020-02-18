<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');

	//Check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1"; //Error code #1 = connection failed
		exit();
	}

	$getusersquery = "SELECT userid, username FROM players";
	mysqli_query($con, $getusersquery) or die("5: user fetch failed");

?>