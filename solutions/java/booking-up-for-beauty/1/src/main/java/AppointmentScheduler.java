import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

class AppointmentScheduler {
    public LocalDateTime schedule(String appointmentDateDescription) {
        DateTimeFormatter parser = DateTimeFormatter.ofPattern("MM/dd/yyyy HH:mm:ss");
        return LocalDateTime.parse(appointmentDateDescription, parser);
    }

    public boolean hasPassed(LocalDateTime appointmentDate) {
        int diff = LocalDateTime.now().compareTo(appointmentDate);

        return diff >= 0;
    }

    public boolean isAfternoonAppointment(LocalDateTime appointmentDate) {
        int appointmentDateHour = appointmentDate.getHour();

        return appointmentDateHour >= 12 && appointmentDateHour < 18;
    }

    public String getDescription(LocalDateTime appointmentDate) {
        DateTimeFormatter printer = DateTimeFormatter.ofPattern("EEEE, LLLL d, yyyy, 'at' h:mm a'.'");

        return "You have an appointment on " + printer.format(appointmentDate);
    }

    public LocalDate getAnniversaryDate() {
        int currentYear = LocalDate.now().getYear();

        return LocalDate.of(currentYear, 9, 15);
    }
}
