<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>JSON+LD Library</title>
</head>

<body>

<script type="application/ld+json">
    {
    "@context": "https://schema.org"
    }
</script>
</body>
</html>

<?
function csvtojson($file,$delimiter)
{
    if (($handle = fopen($file, "r")) === false)
    {
        die("can't open the file.");
    }

    $csv_headers = fgetcsv($handle, 4000, $delimiter);
    $csv_json = array();

    while ($row = fgetcsv($handle, 4000, $delimiter))
    {
        $csv_json[] = array_combine($csv_headers, $row);
    }

    fclose($handle);
    return json_encode($csv_json);
}


$jsonresult = csvtojson("../csv/libraries_information.csv", ",");

echo $jsonresult;
