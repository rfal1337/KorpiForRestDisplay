<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'korpiforrest');

	//Check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1"; //Error code #1 = connection failed
		exit();
	}
	
	$username = $_POST["userID"];
	$starttime = $_POST["starttime"];
	$endtime = $_POST["endtime"];
	$simulationtime = $_POST["simulationtime"];
	$startROS = $_POST["startROS"];
	$endROS = $_POST["endROS"];
	$starttime = str_replace(".", ":",$starttime);
	$endtime = str_replace(".", ":",$endtime);
	
	$insertrosquery = "INSERT INTO ros_results (userID, start_time, end_time, simulation_time, start_ros, end_ros) VALUES ('" . $username . "', '" . $starttime . "', '" . $endtime . "', '" . $simulationtime . "', '" . $startROS . "', '" . $endROS . "');";
	$result = mysqli_query($con, $insertrosquery) or die("10: ROS insertion failed");
	echo "0: ROS saved successfully!";
	

?>