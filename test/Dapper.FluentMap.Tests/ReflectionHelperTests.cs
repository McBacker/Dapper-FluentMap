using System;
using System.Linq.Expressions;
using System.Reflection;
using Dapper.FluentMap.Utils;
using Xunit;

namespace Dapper.FluentMap.Tests
{
    public class ReflectionHelperTests
    {
        [Fact]
        public void GetMemberInfo_ReturnsProperty()
        {
            // Arrange
            Expression<Func<TestEntity, object>> expression = e => e.Id;

            // Act
            var memberInfo = ReflectionHelper.GetMemberInfo(expression);

            // Assert
            Assert.Equal(typeof(TestEntity).GetProperty("Id"), memberInfo);
            Assert.Equal(typeof(int), ((PropertyInfo)memberInfo).PropertyType);
        }

        [Fact]
        public void GetMemberInfo_ReturnsProperty_OfDerivedType()
        {
            // Arrange
            Expression<Func<DerivedTestEntity, object>> expression = e => e.Id;

            // Act
            var memberInfo = ReflectionHelper.GetMemberInfo(expression);

            // Assert
            Assert.Equal(typeof(DerivedTestEntity).GetProperty("Id"), memberInfo);
            Assert.Equal(typeof(int), ((PropertyInfo)memberInfo).PropertyType);
        }

        [Fact]
        public void GetMemberInfo_ReturnsValueTypeProperty()
        {
            // Arrange
            Expression<Func<ValueObjectTestEntity, object>> expression = e => e.Email.Address;

            // Act
            var memberInfo = ReflectionHelper.GetMemberInfo(expression);

            // Assert
            Assert.Equal(typeof(EmailTestValueObject).GetProperty("Address"), memberInfo);
            Assert.Equal(typeof(string), ((PropertyInfo)memberInfo).PropertyType);
        }
    }
}
