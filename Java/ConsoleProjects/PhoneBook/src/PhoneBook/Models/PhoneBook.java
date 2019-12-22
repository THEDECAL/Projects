package PhoneBook.Models;
import java.util.ArrayList;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class PhoneBook {
    private final ArrayList<Abonent> abonents = new ArrayList();

    public void addAbonent(Abonent abon) {
        if(abon != null) {
            if(findAbon(a -> a.getPhoneNumber().equals(abon.getPhoneNumber())) != null)
                throw new IllegalArgumentException("Такой номер телефона уже существует.\n");
            if(findAbon(a -> a.getFname().equals(abon.getFname()) && a.getSname().equals(abon.getSname())) != null)
                throw new IllegalArgumentException("Такое имя и фамилмя  уже существуют.\n");

            abonents.add(abon);
        }
        else throw new NullPointerException();
    }

    public void delAbonent(Abonent abon) {
        if(abon != null)
            abonents.remove(abon);
        else throw new NullPointerException();
    }

    public Abonent findAbon(Predicate<Abonent> findCondition) {
        if(findCondition != null) {
            return abonents.stream()
                    .filter(findCondition).findFirst().orElse(null);
        }
        else throw new NullPointerException();
    }

    public String getAllAbons(){
        var sb = new StringBuilder();

        sb.append("Кол-во записей: " + abonents.size() + "шт\n");
        for(var abon : abonents) {
            sb.append(abon.toString() + '\n');
        }

        return sb.toString();
    }
    public String getAbonsByGroup(Function<? super Abonent,?> groupMethod) {
        var sb = new StringBuilder();
        var abons = abonents.stream().collect(Collectors.groupingBy(groupMethod));

        sb.append("Кол-во записей: " + abonents.size() + "шт\n");
        for (var mapItem : abons.entrySet()) {
            sb.append(mapItem.getKey().toString() + '\n');

            for(var value : mapItem.getValue()){
                sb.append(value.toString() + '\n');
            }
        }

        return sb.toString();
    }

    @Override
    public String toString() {
        return getAllAbons();
    }
}