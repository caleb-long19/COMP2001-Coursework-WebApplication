<?php
include_once 'header.php';
?>

    <main class="container">

        <div class="starter-template text-center py-5 px-3">
            <h1>Plymouth's Libraries: Location and Information</h1>
            <p class="lead">This website is used in order to present meaningful data representation on the<br>
                Plymouth Library Data Set</p>
            <a href="../public/support.php" class="link">Need Help? Click Here</a><br>
        </div>

    </main><!-- /.container -->

    <div class="row g-0 bg-light position-relative">
        <div class="col-md-6 mb-md-0 p-md-4">
            <img src="resources/plymlibrary.jpg" class="w-100" alt="...">
        </div>
        <div class="col-md-6 p-4 ps-md-0">
            <h5 class="mt-0">The Plymouth Library Data Set - 2019</h5>
            <p>This data set contains information on the locations of each library,<br>
                opening/closing times, Names, and locations. If you wish to view the data in a readable format,<br>
                please visit the Library Data Page. If you wish to visit the original data set, please select the link below!</p>
            <a href="https://plymouth.thedata.place/dataset/librariesinformation/resource/c5ec0cb5-4b43-4566-abe9-0bcb5a0ffd46" class="stretched-link">Visit The Original Data Set</a><br>
        </div>
    </div>

    <br>

    <div class="row g-0 bg-light position-relative">
        <div class="col-md-6 mb-md-0 p-md-4">
            <img src="resources/plymunilibrary.png" class="w-100" alt="...">
        </div>
        <div class="col-md-6 p-4 ps-md-0">
            <h5 class="mt-0">Project Vision</h5>
            <p>The vision for this project consists of creating a web based application which has the ability to display<br>
                data on Plymouth's Libraries e.g. Names, Addresses, Longitude/Latitude etc. The only difference is that this will be displayed in a human readable format.
                This means that you can easily understand the data being represented to you. If you wish to see this data, please visit the Library Data Page</p>
            <a href="data.php" class="link">Library Data</a><br>
            <a href="../library/index.php" class="link">View Linked Data</a>
        </div>
    </div>

<?php
include_once 'footer.php';
?>