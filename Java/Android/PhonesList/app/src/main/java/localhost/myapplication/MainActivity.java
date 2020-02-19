package localhost.myapplication;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;
import localhost.myapplication.adapters.PhoneAdapter;
import localhost.myapplication.models.Phone;

public class MainActivity extends AppCompatActivity {
    final static public String LOG_TAG = "MY-LOG";
    final private List<Phone> phones = new ArrayList<Phone>();

    private ListView lvPhonesList;
    private ImageButton ibAddEditPhone;
    private TextView tvPhoneIndex;
    private EditText etBrand;
    private EditText etModel;
    private EditText etPrice;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        getSupportActionBar().hide();
        setContentView(R.layout.activity_main);

        initPhones();
        initViews();

        final PhoneAdapter phoneAddapter = new PhoneAdapter(this, R.layout.phone_item, phones);
        lvPhonesList.setAdapter(phoneAddapter);

        //Обработка нажатия кнопки добавить/изменить
        ibAddEditPhone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    Drawable image = getResources().getDrawable(android.R.drawable.ic_input_add);
                    ibAddEditPhone.setImageDrawable(image);

                    String phoneIndex = tvPhoneIndex.getText().toString();
                    String brand = etBrand.getText().toString();
                    String model = etModel.getText().toString();
                    Double price = 0.0;
                    try {
                        price = Double.parseDouble(etPrice.getText().toString().replace(" грн.", ""));
                    } catch(NumberFormatException e){}
                    Phone phone = new Phone(brand, model, price);

                    tvPhoneIndex.setText("");
                    etBrand.setText("");
                    etModel.setText("");
                    etPrice.setText("");

                    if(phoneIndex.equals("")) { //Если это добавление
                        phones.add(phone);
                    }
                    else{ //Если это изменение
                        Phone findingPhone = phones.get(Integer.parseInt(phoneIndex));
                        if(!phone.equals(findingPhone)){
                            findingPhone.setBrand(brand);
                            findingPhone.setModel(model);
                            findingPhone.setPrice(price);
                        }
                    }

                    phoneAddapter.notifyDataSetChanged();
                }
                catch(Exception e){
                    Log.d(LOG_TAG, e.getMessage());
                }
            }
        });
    }

    protected void initPhones(){
        phones.add(new Phone("Samsung", "Galaxe S9", 10999.0));
        phones.add(new Phone("Nokia", "Nokia 7.2", 6299.0));
        phones.add(new Phone("TP-Link", "Neffos C9a", 1999.0));
    }

    protected void initViews(){
        lvPhonesList = findViewById(R.id.lvPhonesList);
        tvPhoneIndex = findViewById(R.id.tvPhoneIndex);
        etBrand = findViewById(R.id.etBrand);
        etModel = findViewById(R.id.etModel);
        etPrice = findViewById(R.id.etPrice);
        ibAddEditPhone = findViewById(R.id.ibAddEditPhone);
    }
}
