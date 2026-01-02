class Badge {
    public String print(Integer id, String name, String department) {
        String formattedId = null == id ? "" : "[" + String.valueOf(id) + "] - ";
        String formattedDept = null == department ? " - " + "OWNER" : " - " + department.toUpperCase();

        return formattedId + name + formattedDept;
    }
}
