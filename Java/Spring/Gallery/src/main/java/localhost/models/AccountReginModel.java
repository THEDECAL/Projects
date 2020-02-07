package localhost.models;

import lombok.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class AccountReginModel {
    private String login;
    private String password1;
    private String password2;
}
