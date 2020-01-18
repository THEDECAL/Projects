<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<html>
<head>
    <title>Корзина</title>
    <jsp:include page="templates/includes.jsp" />
</head>
<body>
    <div class="container">
        <jsp:include page="templates/menu.jsp"/>
        <br>
        <div class="text-center card-columns justify-content-center">
            <c:forEach var="phone" items="${phones}" varStatus="status">
                <jsp:include page="templates/phoneCardInCart.jsp">
                    <jsp:param name="id" value="${status.index}"/>
                    <jsp:param name="brand" value="${phone.getBrand()}"/>
                    <jsp:param name="model" value="${phone.getModel()}"/>
                    <jsp:param name="imgName" value="${phone.getImgName()}"/>
                    <jsp:param name="price" value="${phone.getPrice().toString()}"/>
                </jsp:include>
            </c:forEach>
        </div>
    </div>
</body>
</html>
