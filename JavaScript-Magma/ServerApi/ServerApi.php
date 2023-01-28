<?php 
$myFile = "status.xml";
$fh = fopen($myFile, 'w') or die("can't open file");
$stringData = print_r(file_get_contents("php://input"),true);
fwrite($fh, $stringData);
fclose($fh);
echo "DONE";
?>