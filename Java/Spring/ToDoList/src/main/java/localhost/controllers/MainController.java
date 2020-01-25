package localhost.controllers;

import localhost.models.Account;
import localhost.models.AccountReginModel;
import localhost.models.Task;
import localhost.repositories.AccountRepository;
import localhost.repositories.TaskRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.Map;

@Controller
public class MainController {
    @Autowired
    AccountRepository accountRepository;
    @Autowired
    TaskRepository taskRepository;

    @GetMapping(path = {"/", "/index"})
    public String index() {
        return "index";
    }

    @GetMapping(path = "/login")
    public String login() {
        return "login";
    }

    @GetMapping(path = "/regin")
    public String regin() {
        return "regin";
    }

    @PostMapping(path = "/regin")
    public String regin(AccountReginModel account, Map<String, Object> model) {
        Account accExist = accountRepository.findByLogin(account.getLogin());

        if(accExist == null){


            return "redirect:/error";
        }

        return "redirect:/login";
    }

    @GetMapping(path = "/add-edit")
    public String addEdit() {
        return "add-edit";
    }

    @PostMapping(path = "/add-edit")
    public String addEdit(Task task, Map<String, Object> model) {
        return "redirect:/index";
    }
}