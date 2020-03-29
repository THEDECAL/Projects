package localhost.models;
import lombok.*;
import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "tasks")
public class Task {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    private String text = "";
    private Boolean isActive = true;

    @ManyToOne
    @JoinColumn(name = "user_id")
    private Account owner;
}
