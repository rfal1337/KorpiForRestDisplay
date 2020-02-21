<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'korpiforrest');

	//Check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1"; //Error code #1 = connection failed
		exit();
	}

	$getusersquery = "SELECT userID, username FROM users";
	$result = mysqli_query($con, $getusersquery) or die("5: user fetch failed");
	$count = $result->num_rows;
	
	if (mysqli_num_rows($result) > 0) {
            while($row = mysqli_fetch_assoc($result)) {
				echo $row["userID"];
				echo "|";
				echo $row["username"];
				echo "\t";
            }
         }
?>