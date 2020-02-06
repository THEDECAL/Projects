package localhost.calculator;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity{
    Character action;
    Double firstNumber; Double secondNumber;
    TextView tvDisplay; TextView tvEnteredNumbers;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initViews();
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        outState.putString("tvDisplay", tvDisplay.getText().toString());
        outState.putString("tvEnteredNumbers", tvEnteredNumbers.getText().toString());

        super.onSaveInstanceState(outState);
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        tvDisplay.setText(savedInstanceState.getString("tvDisplay"));
        tvEnteredNumbers.setText(savedInstanceState.getString("tvEnteredNumbers"));

        super.onRestoreInstanceState(savedInstanceState);
    }

    public void onButtonNumberClick(View v){
        Button btn = (Button)v;
        String currNumber = tvDisplay.getText().toString().trim();
        String defaultTextOnDisplay = getResources().getString(R.string.DefaultTextOnDisplay);

        if(currNumber.equals(defaultTextOnDisplay))
            tvDisplay.setText(btn.getText().toString());
        else
            tvDisplay.append(btn.getText().toString());
    }

    public void onButtonActionClick(View v){
        Button btn = (Button)v;
        try {
            char currAction = btn.getText().charAt(0);
            String currNumberText = tvDisplay.getText().toString();

            if (action != null && !action.equals(currAction))
                    tvEnteredNumbers.setText(tvDisplay.getText().toString().replace(action, currAction));

            action = currAction;

            if(firstNumber == null) {
                firstNumber = Double.parseDouble(currNumberText);;
                tvEnteredNumbers.setText((firstNumber >= 0 ? currNumberText : '(' + currNumberText + ')') + ' ' + action + ' ');
                tvDisplay.setText(getResources().getText(R.string.DefaultTextOnDisplay));
            }
            else if(firstNumber != null && secondNumber != null){
                onButtonAnswerClick(null);
                onButtonActionClick(v);
            }

        }catch(NumberFormatException ex){ runToast("Число не введено"); }
    }

    public void onButtonCommaClick(View v){
        String currEnteredNumber = tvDisplay.getText().toString();
        String comma = getResources().getString(R.string.ButtonComma);

        if(currEnteredNumber.contains(comma))
            tvDisplay.setText(tvDisplay.getText().toString().replace(comma, ""));

        tvDisplay.append(comma);
    }

    public void onButtonClearAllClick(View v){
        String defaultTextOnDisplay = getResources().getString(R.string.DefaultTextOnDisplay);
        tvDisplay.setText(defaultTextOnDisplay);
        tvEnteredNumbers.setText("");
        firstNumber = null;
        secondNumber = null;
    }

    public void onButtonCancelClick(View v){
        String defaultTextOnDisplay = getResources().getString(R.string.DefaultTextOnDisplay);
        tvDisplay.setText(defaultTextOnDisplay);
    }

    public void onButtonEraseClick(View v){
        String currText = tvDisplay.getText().toString();
        String defaultTextOnDisplay = getResources().getString(R.string.DefaultTextOnDisplay);

        tvDisplay.setText(currText.substring(0, currText.length() - 1));
        if(tvDisplay.getText().toString().length() == 0)
            tvDisplay.setText(defaultTextOnDisplay);
    }

    public void onButtonAnswerClick(View v){
        try {
            if (firstNumber != null && action != null) {
                Double answer = null;
                String currNumberText = tvDisplay.getText().toString();
                secondNumber = Double.parseDouble(currNumberText);
                tvEnteredNumbers.append((secondNumber >= 0) ? currNumberText : '(' + currNumberText + ')');

                switch (action) {
                    case '+':
                        answer = firstNumber + secondNumber;
                        break;
                    case '-':
                        answer = firstNumber - secondNumber;
                        break;
                    case '*':
                        answer = firstNumber * secondNumber;
                        break;
                    case '/':
                        answer = (secondNumber == 0) ? 0 : firstNumber / secondNumber;
                        break;
                }

                if (answer - answer.intValue() == 0) {
                    Integer num = answer.intValue();
                    tvDisplay.setText(num.toString());
                    tvEnteredNumbers.append(" = " + num);
                } else {
                    tvDisplay.setText(answer.toString());
                    tvEnteredNumbers.append(" = " + answer.toString());
                }

                firstNumber = secondNumber = null;
                action = null;
            } else runToast("Выберите действие");
        }
        catch(NumberFormatException ex){ runToast("Число не введено"); }
    }

    public void onButtonPlusMinusClick(View v){
        String currNumberText = tvDisplay.getText().toString();

        if(currNumberText.contains("-"))
            tvDisplay.setText(currNumberText.replace("-", ""));
        else
            tvDisplay.setText("-" + currNumberText);
    }

    protected void initViews(){
        tvDisplay = findViewById(R.id.tvDisplay);
        tvEnteredNumbers = findViewById(R.id.tvEnteredNumbers);
    }

    protected void runToast(String text){
        Toast t = Toast.makeText(MainActivity.this, text, Toast.LENGTH_LONG);
        t.setGravity(Gravity.CENTER, 0,0);
        t.show();
    }
}