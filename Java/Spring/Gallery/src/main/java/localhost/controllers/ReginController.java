package localhost.controllers;

import localhost.models.Account;
import localhost.models.AccountReginModel;
import localhost.repositories.AccountRepository;
import lombok.var;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

@Controller
public class ReginController {
    @Autowired
    private AccountRepository accRepo;

    @GetMapping(path = "/regin")
    public String regin(){
        return "regin";
    }

    @PostMapping(path = "/regin")
    public String regin(AccountReginModel acc, RedirectAttributes redirectAtt) {
        Account accExist = accRepo.findByLogin(acc.getLogin());

        if(accExist == null){
            if(acc.getPassword1().equals(acc.getPassword2())) {
                var bcrypt = new BCryptPasswordEncoder();
                var passDecoder = bcrypt.encode(acc.getPassword1());
                accRepo.save(new Account(acc.getLogin(), passDecoder));
            }
            else{
                redirectAtt.addFlashAttribute("error_text", "Пароли не совпадают.");
                return "redirect:/error";
            }
        }
        else {
            redirectAtt.addFlashAttribute("error_text", "Такой логин уже существует.");
            return "redirect:/error";
        }

        return "redirect:/login";
    }
}
