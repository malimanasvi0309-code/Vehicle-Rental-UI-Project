// VehicleRentalUI JavaScript Interactivity

document.addEventListener('DOMContentLoaded', () => {
    // 1. Dynamic Booking Calculator
    const startDateInput = document.getElementById('calcStartDate');
    const endDateInput = document.getElementById('calcEndDate');
    const insuranceSelect = document.getElementById('calcInsurance');
    const dailyRateElem = document.getElementById('calcDailyRate');
    const daysDisplay = document.getElementById('calcTotalDays');
    const rentalSubtotalElem = document.getElementById('calcRentalSubtotal');
    const insuranceElem = document.getElementById('calcInsuranceFee');
    const grandTotalElem = document.getElementById('calcGrandTotal');

    function calculateBooking() {
        if (!startDateInput || !endDateInput || !dailyRateElem || !grandTotalElem) return;

        const start = new Date(startDateInput.value);
        const end = new Date(endDateInput.value);
        const dailyRate = parseFloat(dailyRateElem.getAttribute('data-rate') || '0');

        let diffDays = 1;
        if (!isNaN(start.getTime()) && !isNaN(end.getTime()) && end > start) {
            const timeDiff = end.getTime() - start.getTime();
            diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
        }

        let insuranceFee = 2500;
        if (insuranceSelect) {
            if (insuranceSelect.value === 'Comprehensive') insuranceFee = 2500;
            else if (insuranceSelect.value === 'Basic') insuranceFee = 1200;
            else if (insuranceSelect.value === 'None') insuranceFee = 0;
        }

        const serviceFee = 1500;
        const subtotal = dailyRate * diffDays;
        const total = subtotal + insuranceFee + serviceFee;

        if (daysDisplay) daysDisplay.textContent = `${diffDays} Day${diffDays > 1 ? 's' : ''}`;
        if (rentalSubtotalElem) rentalSubtotalElem.textContent = `₹${subtotal.toLocaleString('en-IN')}`;
        if (insuranceElem) insuranceElem.textContent = `₹${insuranceFee.toLocaleString('en-IN')}`;
        grandTotalElem.textContent = `₹${total.toLocaleString('en-IN')}`;
    }

    if (startDateInput && endDateInput) {
        startDateInput.addEventListener('change', calculateBooking);
        endDateInput.addEventListener('change', calculateBooking);
    }

    if (insuranceSelect) {
        insuranceSelect.addEventListener('change', calculateBooking);
    }

    // Auto-calculate on initial page load if calculator exists
    calculateBooking();

    // 2. Auto-dismiss alerts
    const alerts = document.querySelectorAll('.alert-dismissible');
    alerts.forEach(alert => {
        setTimeout(() => {
            alert.style.transition = 'opacity 0.5s ease';
            alert.style.opacity = '0';
            setTimeout(() => alert.remove(), 500);
        }, 5000);
    });
});
