// Define CSS animation for slide in from the left
$('#alertMessage').css('animation', 'slideInLeft 0.3s forwards');

// Auto close the alert after 5 seconds (5000 milliseconds)
setTimeout(function () {
    // Define CSS animation for slide out to the left
    $('#alertMessage').css('animation', 'slideOutLeft 0.3s forwards');
}, 5000);