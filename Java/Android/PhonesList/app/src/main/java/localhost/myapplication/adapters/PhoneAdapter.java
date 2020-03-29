package localhost.myapplication.adapters;
import android.app.Activity;
import android.content.Context;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.util.List;

import localhost.myapplication.MainActivity;
import localhost.myapplication.R;
import localhost.myapplication.models.Phone;
import localhost.myapplication.tools.FileHelper;

public class PhoneAdapter extends ArrayAdapter<Phone> {
    private LayoutInflater inflater;
    private int layout;
    private List<Phone> phones;

    private TextView tvBrandItem;
    private TextView tvModelItem;
    private TextView tvPriceItem;
    private ImageButton ibRemove;
    private ImageButton ibEdit;

    public PhoneAdapter(@NonNull Context context, int resource, @NonNull List<Phone> objects) {
        super(context, resource, objects);
        phones = objects;
        layout = resource;
        inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public View getView(final int position, @Nullable final View convertView, @NonNull final ViewGroup parent) {
        final View view = inflater.inflate(layout, parent, false);
        initViews(view);

        final Phone phone = phones.get(position);
        tvBrandItem.setText(phone.getBrand());
        tvModelItem.setText(phone.getModel());
        tvPriceItem.setText(phone.getPrice().toString());

        ibRemove.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) { remove(phone); }
        });

        ibEdit.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                try {
                    final Activity mainAct = (Activity) inflater.getContext();
                    final TextView tvPhoneIndex = mainAct.findViewById(R.id.tvPhoneIndex);
                    final EditText etBrand = mainAct.findViewById(R.id.etBrand);
                    final EditText etModel = mainAct.findViewById(R.id.etModel);
                    final EditText etPrice = mainAct.findViewById(R.id.etPrice);
                    final ImageButton ibAddEditPhone = mainAct.findViewById(R.id.ibAddEditPhone);

                    //На случай перехода из режима редактирования меняем икону на "добавить"
                    Drawable image = mainAct.getResources().getDrawable(android.R.drawable.ic_menu_edit);
                    ibAddEditPhone.setImageDrawable(image);

                    tvPhoneIndex.setText(String.valueOf(position));
                    etBrand.setText(phone.getBrand());
                    etModel.setText(phone.getModel());
                    etPrice.setText(phone.getPrice().toString() + " грн.");
                } catch(Exception e) {
                    Log.d(MainActivity.LOG_TAG, e.getMessage());
                }
            }
        });

        return view;
    }

    protected void initViews(View view){
        tvBrandItem = view.findViewById(R.id.tvBrandItem);
        tvModelItem = view.findViewById(R.id.tvModelItem);
        tvPriceItem = view.findViewById(R.id.tvPriceItem);
        ibRemove = view.findViewById(R.id.ibRemove);
        ibEdit = view.findViewById(R.id.ibEdit);
    }
}
